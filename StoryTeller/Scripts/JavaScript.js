
function addAuthor() {
    var uri = 'Animals/Username'
    fetch(uri).then(res => res.json()).then(console.log)
}