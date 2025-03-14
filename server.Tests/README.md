# Lamplist Jobs - Server Tests

Testing suite for the Lamplist server

## Technologies

- XUnit
- Moq

## Usage

### Environment

The `AuthSettings:Key` (for use in JWT signing) is stubbed by the testing framework using an environment variable.

The JWT signing key must be long. Greater than 128 bits.

Set the `LAMPLIST_TEST_KEY` before or during execution of the tests.

Here are some options for setting your environment variable.

```
export LAMPLIST_TEST_KEY=[YOUR TEST KEY HERE]
dotnet test
```

```
dotnet test -e LAMPLIST_TEST_KEY=[YOUR TEST KEY HERE]
```

### Run Tests

To run the unit tests, navigate to the tests directory and run the following command:

```
dotnet test
```
