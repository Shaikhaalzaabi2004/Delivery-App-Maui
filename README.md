# DeliveryApp

A .NET MAUI project for mobile platforms.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022/2023](https://visualstudio.microsoft.com/) with MAUI workload installed
- Android/iOS emulator or physical device

## Setup

1. **Clone the repository**
    ```bash
    git clone <repo-url>
    cd DeliveryApp
    ```

2. **Restore dependencies**
    ```bash
    dotnet restore
    ```

3. **Build and run**
    - For Android:
      ```bash
      dotnet build -t:Run -f net8.0-android
      ```
    - For iOS (Mac required):
      ```bash
      dotnet build -t:Run -f net8.0-ios
      ```

Or use Visual Studio to open the solution and select your target platform.

## Troubleshooting

- Ensure all MAUI workloads are installed:  
  `dotnet workload install maui`
- Update your SDKs and emulators to the latest versions.

## License

MIT