## output to console
awk -F',' 'NR > 1 {print $1", "$3", "$4", "$5", "$6}' ./data/Stock.csv

## output to file
awk -F',' 'NR > 1 {print $1", "$3", "$4", "$5", "$6}' ./data/Stock.csv  >> ./data//output/stock.txt 