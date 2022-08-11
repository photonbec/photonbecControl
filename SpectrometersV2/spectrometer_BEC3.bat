:: Before running a few things need doing.
:: 1. Make the py32 virtual environment and then use pip install on the serial and pydaqmx packages. The spectrometer
:: communication software is 32 bit, hence 32 bit python.
:: 2. Make sure conda is added to PATH
:: 3. Run the command that allows conda to run from the command prompt (if you just try run this script
:: without doing this it will tell you how to do it.)

CALL conda activate py32 && python single_spec_server_main.py
