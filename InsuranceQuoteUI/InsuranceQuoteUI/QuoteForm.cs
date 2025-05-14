using InsuranceQuoteUI.Models;
using InsuranceQuoteUI.Services;
using System.Globalization;

namespace InsuranceQuoteUI
{
    public partial class QuoteForm : Form
    {
        private readonly InsuranceQuoteService _quoteService;
        private QuoteResponse? _currentQuote;

        public QuoteForm()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

            _quoteService = new InsuranceQuoteService();
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            // Set up currency formatting for sum insured input
            numSumInsured.ThousandsSeparator = true;
            numSumInsured.DecimalPlaces = 2;

            // Initialize status
            lblStatus.Text = "Status: Ready";

            // Set up initial state where there's no quote details yet
            pnlQuoteDetails.Visible = false;
            dgvQuotes.Visible = false;
        }

        private async void btnGetQuote_Click(object sender, EventArgs e)
        {
            try
            {
                // Update UI to show processing state
                btnGetQuote.Enabled = false;
                btnRetrieveQuote.Enabled = false;
                lblStatus.Text = "Status: Requesting quote...";
                Cursor = Cursors.WaitCursor;

                // Create the quote request from form inputs
                var request = new QuoteRequest
                {
                    Term = (int)numTerm.Value,
                    SumInsured = numSumInsured.Value
                };

                // Submit the quote request to API
                var quoteId = await _quoteService.SubmitQuoteAsync(request);

                // Update the UI with the quote ID
                txtQuoteId.Text = quoteId.ToString();

                // Retrieve the quote details
                await RetrieveQuoteAsync(quoteId);

                lblStatus.Text = "Status: Quote retrieved successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting quote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Status: Error - {ex.Message}";
            }
            finally
            {
                btnGetQuote.Enabled = true;
                btnRetrieveQuote.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async void btnRetrieveQuote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuoteId.Text))
            {
                MessageBox.Show("Please enter a Quote ID to retrieve", "Missing Quote ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!Guid.TryParse(txtQuoteId.Text, out var quoteId))
                {
                    MessageBox.Show("Invalid Quote ID format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnGetQuote.Enabled = false;
                btnRetrieveQuote.Enabled = false;
                lblStatus.Text = "Status: Retrieving quote...";
                Cursor = Cursors.WaitCursor;

                await RetrieveQuoteAsync(quoteId);

                lblStatus.Text = "Status: Quote retrieved successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving quote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = $"Status: Error - {ex.Message}";
            }
            finally
            {
                btnGetQuote.Enabled = true;
                btnRetrieveQuote.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task RetrieveQuoteAsync(Guid? quoteId)
        {
            // Get the quote details from the API
            _currentQuote = await _quoteService.GetQuoteAsync(quoteId);

            // Display quote details in the panel
            lblDetailsTerm.Text = $"Term: {_currentQuote?.Term} months";

            var usCulture = new CultureInfo("en-US");
            lblDetailsSumInsured.Text = $"Sum Insured: {_currentQuote?.SumInsured.ToString("C", usCulture)}";
            lblDetailsCreatedAt.Text = $"Created At: {_currentQuote?.CreatedAt}";

            // Make the panel visible
            pnlQuoteDetails.Visible = true;

            // Display the quotes in the data grid
            DisplayQuotes(_currentQuote);
        }

        private void DisplayQuotes(QuoteResponse? quote)
        {
            // Prepare the data grid
            dgvQuotes.DataSource = null;

            // Sort quotes by premium from lowest to highest for better user experience
            var sortedQuotes = quote?.CompanyQuotes.OrderBy(q => q.Premium).ToList();
            dgvQuotes.DataSource = sortedQuotes;

            // Format the premium column
            if (dgvQuotes.Columns.Contains("Premium"))
            {
                var usCulture = new CultureInfo("en-US");
                dgvQuotes.Columns["Premium"].DefaultCellStyle.Format = "C";
                dgvQuotes.Columns["Premium"].DefaultCellStyle.FormatProvider = usCulture;
            }

            // Highlight the lowest premium quote
            if (dgvQuotes.Rows.Count > 0)
            {
                dgvQuotes.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
            }

            dgvQuotes.Visible = true;
        }
    }
}
