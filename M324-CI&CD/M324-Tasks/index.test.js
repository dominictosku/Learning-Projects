import { strict as assert } from "assert";
import { sum } from "./index.js";

describe("sum", () => {
  it("should return 3 for 1 + 2", () => {
    // Korrigieren Sie den Test
    assert.equal(sum(1, 2), 3);
  });

  it("should return 4 for 2 + 2", () => {
    // Korrigieren Sie den Test
    assert.equal(sum(2, 2), 4);
  });

  it("should return 4.5 for 2.5 + 2", () => {
    // Korrigieren Sie den Test
    assert.equal(sum(2.5, 2), 4.5);
  });
});