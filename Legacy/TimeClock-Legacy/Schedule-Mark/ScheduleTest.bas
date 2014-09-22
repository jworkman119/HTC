Attribute VB_Name = "Module1"
Sub ScheduleTest()
Attribute ScheduleTest.VB_ProcData.VB_Invoke_Func = " \n14"
'
' ScheduleTest Macro
'

'
    Dim strCSV As String
    Dim strDate As String
    Sheets(3).Select
    
    strDate = Replace(CStr(Date), "/", "")
    strCSV = "\\iomega-nas\Public1\IT Department\Jeremy\StateFair\2011\" + strDate + "MorningSchedule.csv"
    Sheets(3).SaveAs (strCSV) 'SaveAs (strCSV)
End Sub
