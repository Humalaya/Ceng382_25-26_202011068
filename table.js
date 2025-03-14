document.addEventListener("DOMContentLoaded", function() {
    document.getElementById('classForm').addEventListener('submit', function(e) {
        e.preventDefault();

        // Get input values
        let className = document.getElementById('className').value;
        let numPeople = document.getElementById('numPeople').value;
        let description = document.getElementById('description').value;

        // Create new table row
        let table = document.getElementById('classTable').getElementsByTagName('tbody')[0];
        let newRow = table.insertRow();
        newRow.innerHTML = `
            <td>${className}</td>
            <td>${numPeople}</td>
            <td>${description}</td>
        `;

        // Clear form after submission
        document.getElementById('classForm').reset();
    });
});
