#include "convert.h"
#include <iostream>
#include <string>
using namespace std;

void decode_csv(char* input_file, char* output_file) {
	fstream encoded_file, decoded_file;
	encoded_file.open(input_file, ios::in);
	decoded_file.open(output_file, ios::out);
	if (encoded_file.is_open()) {
		string encoded, decoded;
		while (getline(encoded_file, encoded)) {
			decoded = base64_decode(encoded);
			decoded_file << decoded << "\n";
		}
		encoded_file.close();
		decoded_file.close();
	}
}

void delete_csv(char* filename){
	remove(filename);
}

void encode_csv(char* input_file, char* output_file) {
	fstream encoded_file, decoded_file;
	encoded_file.open(output_file, ios::out);
	decoded_file.open(input_file, ios::in);
	if (decoded_file.is_open()) {
		string encoded, decoded;
		while (getline(decoded_file, decoded)) {
			encoded = base64_encode(decoded);
			encoded_file << encoded << "\n";
		}
		encoded_file.close();
		decoded_file.close();
	}
}