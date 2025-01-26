#!/usr/bin/awk -f

BEGIN {
    FS=",";  # Set field separator as comma
    print "----------------------------------------------";  # Print table top border
}

NR == 1 {
    # Print header with symmetry and underline
    printf("      | %-4s | %-14s | %-6s | %-5s | %-9s | %-10s |\n", substr($1,1,3), $2, $3, $4, $5, $6);
    print "      |------|----------------|--------|-------|-----------|------------|";
}

NR > 1 {
    # Print each data row formatted as a table row
    printf("      | %-4s | %-14s | %-6s | %-5s | %-9s | %-10s |\n", substr($1,1,3), $2, $3, $4, $5, $6);
}

END {
    print "----------------------------------------------";  # Print table bottom border
}
