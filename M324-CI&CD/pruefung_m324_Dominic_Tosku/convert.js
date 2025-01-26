import Showdown from "showdown"; // Why showdown? It has many downloads and updated not long ago
import fs from "fs/promises";

async function convertMarkdownToHtml(inputFile, outputFile) {
  try {
    const markdownContent = await fs.readFile(inputFile, "utf-8");

    const converter = new Showdown.Converter();

    const htmlContent = converter.makeHtml(markdownContent);

    await fs.writeFile(outputFile, htmlContent, "utf-8");

    console.log(`Conversion complete! HTML saved to ${outputFile}`);
  } catch (error) {
    console.error("An error occurred:", error.message);
  }
}

const inputMarkdownFile = "task-3.md";
const outputHtmlFile = "task-3.html";

convertMarkdownToHtml(inputMarkdownFile, outputHtmlFile);
