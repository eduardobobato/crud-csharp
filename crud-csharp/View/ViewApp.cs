using crud_csharp.Controller;
using crud_csharp.enums;
using crud_csharp.exceptions;
using crud_csharp.Model;
using crud_csharp.Service;
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
                    Console.WriteLine(I18nService.GetTranslate("INSERT_NEW_ENDPOINT_MENU"));
                    Console.WriteLine(I18nService.GetTranslate("EDIT_ENDPOINT_MENU"));
                    Console.WriteLine(I18nService.GetTranslate("DELETE_ENDPOINT_MENU"));
                    Console.WriteLine(I18nService.GetTranslate("LIST_ALL_ENDPOINT_MENU"));
                    Console.WriteLine(I18nService.GetTranslate("FIND_ENDPOINT_MENU"));
                    Console.WriteLine(I18nService.GetTranslate("EXIT_MENU"));
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
                            Console.WriteLine(I18nService.GetTranslate("INVALID_INPUT_TRY_AGAIN"));
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
            Console.WriteLine(I18nService.GetTranslate("INSERT_NEW_ENDPOINT"));
            Console.Write(I18nService.GetTranslate("SERIAL_NUMBER") + ": ");
            var serialNumber = Console.ReadLine();
            Console.Write(I18nService.GetTranslate("METER_MODEL_ID") + string.Format(" ({0} | {1} | {2} | {3}): ", ModelId.NSX1P2W, ModelId.NSX1P3W, ModelId.NSX1P4W, ModelId.NSX1P5W));
            var modelId = Console.ReadLine();
            Console.Write(I18nService.GetTranslate("METER_NUMBER") + ": ");
            var meterNumber = Console.ReadLine();
            Console.Write(I18nService.GetTranslate("METER_FIRMWARE_VERSION") + ": ");
            var firmwareVersion = Console.ReadLine();
            Console.Write(I18nService.GetTranslate("SWITCH_STATE") + string.Format(" ({0} | {1} | {2}): ", SwitchState.Disconnected, SwitchState.Connected, SwitchState.Armed));
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
            Console.WriteLine(I18nService.GetTranslate("SUCCESSLY_CREATED_ENDPOINT"));
            PressAnyKeyToContinue();
        }

        private void EditEndpointView()
        {
            Console.WriteLine(I18nService.GetTranslate("EDIT_ENDPOINT"));
            Console.Write(I18nService.GetTranslate("SERIAL_NUMBER") + ": ");
            var serialNumber = Console.ReadLine();
            Console.Write(I18nService.GetTranslate("SWITCH_STATE") + string.Format(" ({0} | {1} | {2}): ", SwitchState.Disconnected, SwitchState.Connected, SwitchState.Armed));
            var switchState = Console.ReadLine();
            
            var newEndpoint = new EndpointVO()
            {
                serialNumber = serialNumber,
                switchState = switchState,
            };

            var endpoint = endpointController.Edit(newEndpoint);
            Console.WriteLine(I18nService.GetTranslate("SUCCESSLY_EDITED_ENDPOINT"));
            PressAnyKeyToContinue();
        }

        private void DeleteEndpointView()
        {
            Console.WriteLine(I18nService.GetTranslate("DELETE_ENDPOINT"));
            Console.Write(I18nService.GetTranslate("SERIAL_NUMBER") + ": ");
            var identifier = Console.ReadLine();
            endpointController.Delete(identifier);
            Console.WriteLine(I18nService.GetTranslate("SUCCESSLY_DELETED_ENDPOINT"));
            PressAnyKeyToContinue();
        }

        private void ListAllEndpointView()
        {
            var endpointList = endpointController.ListAll();
            Console.WriteLine(I18nService.GetTranslate("LIST_ALL_ENDPOINT"));
            foreach (var endpoint in endpointList)
            {
                Console.WriteLine(endpoint.ToString());
            }
            PressAnyKeyToContinue();
        }

        private void FindEndpointView()
        {
            Console.WriteLine(I18nService.GetTranslate("FIND_ENDPOINT"));
            Console.Write(I18nService.GetTranslate("SERIAL_NUMBER") + ": ");
            var identifier = Console.ReadLine();
            var endpoint = endpointController.FindOne(identifier);
            Console.WriteLine(endpoint.ToString());
            PressAnyKeyToContinue();
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine(I18nService.GetTranslate("PRESS_ANY_KEY_TO_CONTINUE"));
            Console.ReadKey();
        }
    }
}
