#!/bin/bash

INPUT_FILE="README.md"
OUTPUT_FILE="index.html"

if [ ! -f "$INPUT_FILE" ]; then
    echo "Die Datei $INPUT_FILE wurde nicht gefunden."
    exit 1
fi

pandoc "$INPUT_FILE" -o "$OUTPUT_FILE"
echo "Konvertierung abgeschlossen: $OUTPUT_FILE wurde erstellt."
