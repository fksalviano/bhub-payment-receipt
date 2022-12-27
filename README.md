# BHub-PaymentReceipt

.Net Core API using Clean Architecture and Vertical Slice solving the BHub tech challenge.

The tech challenge was solved using the follow:

## Application

- ### ProcessReceiptUseCase
    Use case responsible to process a payment receipt that was sent by the API.

    Uses a **ReceiptProcessorFactory** to get  one of the following specific **ReceiptProcessor** to process the payment receipt.
    
    By default, all the specific processor call and executes the default processor before execute your own routine to process.

    - **DefaultReceiptProcessor**
    - **FisicalProductProcessor**
    - **BookProductProcessor**
    - **VideoProductProcessor**
    - **MembershipProcessor**
    - **MembershipUpgradeProcessor**

## Worker

The API micro-service with the Controller and Endpoint to process the payment receipt.

## Dependency Injection

The project uses Dependence Injection to build the container of services and uses an installer to add the use case and it´s dependencies  on the container.

## Configuration

### Requirements

Need to install the following:

- Git:
    https://git-scm.com/downloads

- Dotnet Core 6.0 SDK and Runtime:
    https://dotnet.microsoft.com/en-us/download/dotnet/6.0


## Getting Started

#### Clone the repository:

```bash
git clone https://github.com/fksalviano/bhub-payment-receipt.git
```

#### Go to the project directory

```bash
cd bhub-payment-receipt
```

#### Build the project

```bash
dotnet build
```

#### Run the project

```bash
dotnet run --project src/Worker
```

#### Access the Swagger UI

https://localhost:7128/swagger/index.html


## Packages

The project uses the following packages

- XUnit:
    https://www.nuget.org/packages/xunit

- Moq.AutoMock:
    https://www.nuget.org/packages/moq.automock
