class Parkcalc
  def initialize
    @BaseURL = "http://localhost/parkcalc"
    
    
    # Controls
    @btnCalculate     = {:type => "button", :name => "Submit"}
    @rdoEntryTimeAMPM = {:type => "radiobutton", :name => "EntryTimeAMPM"}
    @rdoExitTimeAMPM  = {:type => "radiobutton", :name => "ExitTimeAMPM"}
    @ddlLot           = {:type => "select",:id => "Lot"}
    @txtEntryTime     = {:type => "text", :id => "EntryTime"}
    @txtEntryDate     = {:type => "text", :id => "EntryDate"}
    @txtExitTime      = {:type => "text", :id => "ExitTime"}
    @txtExitDate      = {:type => "text", :id => "ExitDate"}
    @txtAction        = {:type => "text", :name =>"action"}
    @txtResult        = {:type => "div", :id => "result"}
  end

  attr_accessor :BaseURL,:btnCalculate, :rdoEntryTimeAMPM, :rdoExitTimeAMPM, :ddlLot, :txtEntryTime,
                :txtEntryDate, :txtExitTime, :txtExitDate, :txtAction, :txtResult
end

