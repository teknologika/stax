require './stax'
require './parkcalc'

stax = Stax.new
parkcalc = Parkcalc.new

stax.GoTo(parkcalc.BaseURL)
stax.SetValue(parkcalc.ddlLot, "Valet Parking")
stax.SetValue(parkcalc.rdoEntryTimeAMPM,"PM")
stax.SetValue(parkcalc.rdoExitTimeAMPM,"PM")

stax.SetValue(parkcalc.txtEntryTime, "01:00")
stax.SetValue(parkcalc.txtExitTime, "02:00")
stax.SetValue(parkcalc.txtEntryDate, "01/01/2012")
stax.SetValue(parkcalc.txtExitDate, "01/01/2012")

stax.Invoke(parkcalc.btnCalculate)

stax.GetValue(parkcalc.txtResult)

stax.Close


