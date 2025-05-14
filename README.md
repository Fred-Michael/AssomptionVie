# Insurance Premium Quoting System

This project is a mock insurance premium quoting system composed of an ASP.NET Core REST API backend and a Windows Forms client application.

## Project Structure

The solution consists of two projects:

1. **InsuranceQuoteAPI** - An ASP.NET Core REST API that provides endpoints for quote submission and retrieval
2. **InsuranceQuoteClient** - A Windows Forms application that consumes the API and displays quote information

## API Features

The API provides two main endpoints:

1. **Quote Submission** (`POST /api/Quotes`) - Takes term and sum insured as input parameters and returns a quote ID
2. **Quote Retrieval** (`GET /api/Quotes/{id}`) - Returns quote details including four different premiums from imaginary insurance companies

## Client Features

The Windows Forms client application allows users to:

1. Input term and sum insured values
2. Submit quote requests to the API
3. Retrieve quotes using a quote ID
4. View detailed quote information including:
   - Quote ID
   - Term
   - Sum Insured
   - Creation date/time
   - Premiums from four different companies
   - Highlighting of the lowest premium

## Running the Solution

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022 or later (recommended)

### Setup Steps

1. Clone or download the repository
2. Open the solution in Visual Studio
3. Set both projects as startup projects (right-click the solution, Properties -> Startup Project -> Multiple startup projects)
4. Press F5 to run both the API and the client application

Alternatively, you can start them separately:

1. Start the API first:
   ```
   cd InsuranceQuoteAPI
   dotnet run
   ```

2. Then start the client:
   ```
   cd InsuranceQuoteClient
   dotnet run
   ```

## How It Works

1. The API maintains a dictionary of quotes in memory (persisting for the lifetime of the API)
2. Each quote is assigned a unique GUID identifier
3. The API generates four different premium amounts using slightly different formulas for each company
4. The client application communicates with the API using HTTP requests
5. The client displays the quotes in a data grid, highlighting the lowest premium

## Code Overview

### API

- **Models**: Define the data structures for quote requests and responses
- **Services**: Implement the business logic for quote generation
- **Controllers**: Handle HTTP requests and responses

### Client

- **Models**: Mirror the API data structures
- **Services**: Handle API communication
- **Forms**: Provide the user interface

## Technical Implementation Details

- In-memory storage using `ConcurrentDictionary` for thread safety
- Unique identification of quotes using GUIDs
- Premium calculation with company-specific factors and random variation
- Error handling and validation on both the API and client sides
- Responsive UI with status updates and cursor changes during operations
