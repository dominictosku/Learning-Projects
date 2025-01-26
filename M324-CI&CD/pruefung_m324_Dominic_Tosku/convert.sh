#!/bin/bash

INPUT_FILE="task-3.md"
OUTPUT_FILE="task-3.html"

if [ ! -f "$INPUT_FILE" ]; then
    echo "Die Datei $INPUT_FILE wurde nicht gefunden."
    exit 1
fi

pandoc "$INPUT_FILE" -o "$OUTPUT_FILE" # apt install pandoc
echo "Konvertierung abgeschlossen: $OUTPUT_FILE wurde erstellt."
