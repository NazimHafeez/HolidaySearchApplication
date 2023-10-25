# Input Sources
	Each json file in this source folder acts as an input to populate the source data against which the user queries are executed and result object being constructed.

## Input Sources
	Two input sources are used for this example. One is to feed in the flight data and the second to feed in the hotel information.
	Ideally we want the sources to be dynamically added but given the different nature of the two data constucts (flight and hotel) it will be a bigger task for this exercise.

## Possible Improvements
	Both for the flights and for the hotels there could be multiple sources feeding the data into our application. It will be best if we create an abstraction layer around the
	input types (flight and hotel) and irrespective of where the data is coming we should be able to cosume it for our application.

