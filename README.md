# DeliveryApp

A .NET MAUI project for mobile platforms.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
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


## Backend Integration

This app requires integration with the backend API repository: [Delivery-App-Maui-API](https://github.com/Shaikhaalzaabi2004/Delivery-App-Maui-API).  
Follow the backend setup instructions in that repository and ensure the API is running before using the mobile app.

> **Note:**  
> To connect the app to your backend API, update the IP address in the `ApiRequests.cs` file located in the `Helper` folder.  
> Set the IP to match your API server's address before running the app.

## License

MIT