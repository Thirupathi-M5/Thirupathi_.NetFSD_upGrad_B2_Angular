const marks=[75,80,65,55]
const processedMarks = marks.map(mark => mark)
const total = processedMarks.reduce((sum, mark) => sum + mark, 0)
const average = total/processedMarks.length
const result = average >= 40? "pass" : "Fail"

console.log(`Marks: ${processedMarks}`)
console.log(`Total: ${total}`)
console.log(`Average: ${average.toFixed(2)}`)
console.log(`Result: ${result}`)

