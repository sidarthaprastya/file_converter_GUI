#define convert _declspec(dllexport)

#include "base64.h"
#include <fstream>
#include <string>

extern "C" {
	convert void decode_csv(char* input_file, char* output_file);

	convert void delete_csv(char* filename);
}

//void decode_csv(char* input_file, char* output_file);

//void delete_csv(char* filename);


