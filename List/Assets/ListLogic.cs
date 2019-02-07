using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLogic : MonoBehaviour
{
    #region Declare variables

    // Value types
    private List<int> values = new List<int>();

    // Reference types
    public Text listboxList;
    public Text listboxLog;
    public InputField inputParam;
    public InputField inputIndex;
    public KeyCode tab;
    public KeyCode kReturn;
    public KeyCode leftShift;
    public KeyCode backspace;
    public KeyCode space;

    #endregion

    #region Main function "Start()"

    void Start()
    {
        // Algorithm
        FocusInputParam();
    }

    #endregion

    #region Main function "Update()"

    void Update()
    {
        // Algorithm
        SwitchTextbox();
        InputKey();
    }

    #endregion

    #region Custom functions

    #region Functions for "Start()"

    void FocusInputParam()
    {
        inputParam.ActivateInputField();
    }

    #endregion

    #region Functions for "Update()"

    void SwitchTextbox()
    {
        if (Input.GetKeyDown(tab) && inputParam.isFocused)
        {
            inputIndex.text = "";
            inputIndex.ActivateInputField();
        }
        else if (Input.GetKeyDown(tab) && inputIndex.isFocused)
        {
            inputParam.text = "";
            inputParam.ActivateInputField();
        }
        else if (Input.GetKeyDown(tab) && !inputParam.isFocused && !inputIndex.isFocused)
        {
            inputParam.text = "";
            inputParam.ActivateInputField();
        }
    }

    void InputKey()
    {
        if (Input.GetKeyDown(kReturn))
            AddParam();
        else if (Input.GetKeyDown(leftShift))
            GetLength();
        else if (Input.GetKeyDown(backspace))
            Remove();
        else if (Input.GetKeyDown(space))
            AddIndex();
    }

    #endregion

    #region Other auxiliary functions

    /// <summary>
    /// Add(int param)
    /// </summary>
    public void AddParam()
    {
        try
        {
            Add(int.Parse(inputParam.text));
        }
        catch
        {
            listboxLog.text = "Input param was not in the correct format!";
        }
    }
    private void Add(int param)
    {
        // Clear inputParam
        inputParam.text = "";

        // Set focus of inputParam
        inputParam.ActivateInputField();

        // Add param in the list values
        values.Add(param);

        // Output listboxLog
        listboxLog.text = "You added value " + param + ".";

        // Algorithm
        OutputValues();
    }

    /// <summary>
    /// GetLength()
    /// </summary>
    public void GetLength()
    {
        // Output listboxLog 
        listboxLog.text = "The length from list is " + values.Count + ".";
    }

    /// <summary>
    /// Remove()
    /// </summary>
    public void Remove()
    {
        try
        {
            // Remove last item
            values.RemoveAt(values.Count - 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            // Nothing, because i don't get error in debug window
        }

        // Algorithm
        OutputValues();
        GetLength();
    }

    /// <summary>
    /// RemoveAt(int index)
    /// </summary>
    public void AddIndex()
    {
        try
        {
            RemoveAt(int.Parse(inputIndex.text));
        }
        catch (FormatException)
        {
            listboxLog.text = "Input index was not in the correct format!";
        }
        catch (ArgumentOutOfRangeException)
        {
            listboxLog.text = "List index out of range!";
        }
    }
    private void RemoveAt(int index)
    {
        // Clear inputIndex
        inputIndex.text = "";

        // Set focus of inputIndex
        inputIndex.ActivateInputField();

        // Remove specific item
        values.RemoveAt(index - 1);

        // Algorithm
        OutputValues();
        GetLength();
    }

    /// <summary>
    /// Fill listboxList.
    /// </summary>
    void OutputValues()
    {
        // Clear listboxList
        listboxList.text = "";

        // Output the list values in listboxList
        for (int i = 0; i < values.Count; i++)
            listboxList.text += Convert.ToString(values[i]) + ", ";
    }

    #endregion

    #endregion
}
