import chalk from 'chalk'
import { generate } from 'random-words'

const word1 = generate({ exactly: 1, minLength: 10, wordsPerString: 1 })
const word2 = generate()
console.log(`The ${chalk.greenBright(word1)} is ${chalk.redBright(word2)}.`)

export const sum = (a, b) => {
  return a + b;
};

console.log("Hello pull request")