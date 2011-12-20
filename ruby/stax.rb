require 'selenium-webdriver'
require 'rubygems'

class Stax
  def initialize 
    @@browser = Selenium::WebDriver.for :firefox
  end
  
  def test
    puts "test"
  end
  
  def GoTo(url)
    @@browser.get url
  end 
  
  def SetValue(control, value)
    type = control.delete(:type)
    puts "The control type is: " + type
    puts "Setting the value to: " + value
    element = @@browser.find_element control
    
    
    case type
      when "select" then
        # the classic drop down list
        all_options = element.find_elements(:tag_name, "option")
        all_options.each do |option| 
        if value == option.text then
          option.click
          break
        end
      end
        
      when "radiobutton" then
        # We need to get a group of controls
        all_radios =  @@browser.find_elements(control)
        all_radios.each do |radio| 
        if value == radio.attribute("value") then
          radio.click
          break
        end
      end
         
      # Text boxes
      when "text" then
        element.clear
        element.send_keys value
      else
        puts 'WARNING: Control type not defined.'
      
    end
  end
  
  def Invoke(control)
    type = control.delete(:type)
    
    # need to support button, submit, link, image, radiobutton
    element = @@browser.find_element control
    element.click
  end
  
  def GetValue(control)
    type = control.delete(:type)
    element = @@browser.find_element control
    
    element.text
    puts "The returned value is " + element.text
  end
  
  def Close()
    @@browser.quit
  end
end