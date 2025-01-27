using Microsoft.Win32; // Library to access the windows registery
using System;

public class RegisteryUtils
{
    /// <summary>
    /// Showcases how to read data from a Windows Registery key.
    /// </summary>
    /// <returns>The object retrieved from the Registery, Returns null if no value is retrieved.</returns>
    public static object ReadFromReg(string keyPath, string valueName)
    {
        object retrievedObj = null;

        try
        {
            // Get data in the given win reg key and var name
            retrievedObj = Registry.GetValue(keyPath, valueName, null);
        }
        catch (Exception ex)
        {
            // TODO: Log error
        }

        return retrievedObj;
    }

    /// <summary>
    /// Showcases how to (over)write data to a Windows Registery key.
    /// If the key is not found it will create a new key
    /// </summary>
    /// <returns>True if the retrieval is valid False otherwise.</returns>
    public static bool WriteToReg(string keyPath, string valueName, object variableValue, RegistryValueKind registryValueKind)
    {
        bool retrievalResult = false;

        try
        {
            // Set data in the given win reg key
            Registry.SetValue(keyPath, valueName, variableValue, registryValueKind);
            retrievalResult = true;
        }
        catch (Exception ex)
        {
            // TODO: Log error
            retrievalResult = true;
        }

        return retrievalResult;
    }

    /// <summary>
    /// Deletes an element from a Windows Registery key.
    /// </summary>
    /// <returns>True if the deletion is valid False otherwise.</returns>
    public bool DeleteFromReg(string keyPath, string valueName)
    {
       bool deleteResult = false;
        try
        {
            // Open the registry key in read/write mode with explicit registry view
            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            {
                using (RegistryKey key = baseKey.OpenSubKey(keyPath, true)) // Get the reg key
                {
                    if (key != null)
                    {
                        // Delete the specified value
                        key.DeleteValue(valueName);
                        deleteResult = true;
                    }
                    else
                    {
                        // TODO: Log Error
                    }
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            // TODO: Log(UnauthorizedAccessException: Run the program with administrative privileges)
        }
        catch (Exception ex)
        {
            // TODO: Log error ex;
        }

        return deleteResult;
    }
}
