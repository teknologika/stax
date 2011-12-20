


/
require 'google'

stax = Stax.new
google = Google.new

stax.GoTo(google.BaseURL)
stax.SetValue(google.txtQ,"Hello World")
stax.Invoke(google.btnK)

stax.Close

/


class Google
  def initialize
    @BaseURL = "http://www.google.com"
    
    
    # Controls
    @txtQ = {:name => "q" }
    @btnK = {:name => "btnK" }
    @btnI = {:name => "btnI" }
  end

  attr_accessor :BaseURL,:txtQ, :btnK, :btnI
end