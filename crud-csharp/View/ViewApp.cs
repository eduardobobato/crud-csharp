using crud_csharp.Controller;
using crud_csharp.exceptions;
using crud_csharp.Model;
using crud_csharp.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace crud_csharp.View
{
    public class ViewApp
    {
        private static EndpointController endpointController = new EndpointController();

        public void StartApp()
        {
            var input = ConsoleKey.NumPad0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1 - Insert new endpoint");
                    Console.WriteLine("2 - Edit endpoint by serial number");
                    Console.WriteLine("3 - Delete endpoint by serial number");
                    Console.WriteLine("4 - List all endpoints");
                    Console.WriteLine("5 - Find endpoint by serial number");
                    Console.WriteLine("6 - Exit");
                    input = Console.ReadKey().Key;
                    Console.Clear();
                    switch (input)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            InsertEndpointView();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            EditEndpointView();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            DeleteEndpointView();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            ListAllEndpointView();
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            FindEndpointView();
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            break;
                        default:
                            Console.WriteLine("Invalid input, try again...");
                            PressAnyKeyToContinue();
                            break;
                    }
                }
                catch (AppException e)
                {
                    Console.WriteLine(e.Message);
                    PressAnyKeyToContinue();
                }
            } while (input != ConsoleKey.NumPad6 && input != ConsoleKey.D6);
        }

        private void InsertEndpointView()
        {
            Console.WriteLine("Insert new endpoint:");
            Console.Write("Serial number: ");
            var serialNumber = Console.ReadLine();
            Console.Write("Model id: ");
            var modelId = Console.ReadLine();
            Console.Write("Meter number: ");
            var meterNumber = Console.ReadLine();
            Console.Write("Firmware version: ");
            var firmwareVersion = Console.ReadLine();
            Console.Write("Switch state: ");
            var switchState = Console.ReadLine();
            
            var newEndpoint = new EndpointVO()
            {
                serialNumber = serialNumber,
                meterModelId = modelId,
                meterNumber = meterNumber,
                meterFirmwareVersion = firmwareVersion,
                switchState = switchState
            };

            var endpoint = endpointController.Create(newEndpoint);
            Console.WriteLine("Successfully created endpoint.");
            PressAnyKeyToContinue();
        }

        private void EditEndpointView()
        {
            Console.WriteLine("Edit endpoint by serial number:");
            Console.Write("Serial number: ");
            var serialNumber = Console.ReadLine();
            Console.Write("Switch state: ");
            var switchState = Console.ReadLine();
            
            var newEndpoint = new EndpointVO()
            {
                serialNumber = serialNumber,
                switchState = switchState,
            };

            var endpoint = endpointController.Edit(newEndpoint);
            Console.WriteLine("Successfully edited endpoint.");
            PressAnyKeyToContinue();
        }

        private void DeleteEndpointView()
        {
            Console.WriteLine("Delete endpoint by serial number:");
            Console.Write("Serial number: ");
            var identifier = Console.ReadLine();
            endpointController.Delete(identifier);
            Console.WriteLine("Successfully deleted endpoint.");
            PressAnyKeyToContinue();
        }

        private void ListAllEndpointView()
        {
            var endpointList = endpointController.ListAll();
            Console.WriteLine("List all endpoint:");
            foreach (var endpoint in endpointList)
            {
                Console.WriteLine(endpoint.ToString());
            }
            PressAnyKeyToContinue();
        }

        private void FindEndpointView()
        {
            Console.WriteLine("Find endpoint by serial number:");
            Console.Write("Serial number: ");
            var identifier = Console.ReadLine();
            var endpoint = endpointController.FindOne(identifier);
            Console.WriteLine(endpoint.ToString());
            PressAnyKeyToContinue();
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
