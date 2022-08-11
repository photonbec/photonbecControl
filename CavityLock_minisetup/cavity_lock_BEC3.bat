:: Before running a few things need doing.
:: 1. Make the cavitylock virtual environment and then use pip install to add the spinnaker package
:: serial and pydaqmx packages.
:: 2. Make sure conda is added to PATH
:: 3. Run the command that allows conda to run from the command prompt (if you just try run this script
:: without doing this it will tell you how to do it.)
CALL conda activate cavitylock && python cavity_lock.py

