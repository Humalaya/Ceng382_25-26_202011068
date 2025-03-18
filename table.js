document.addEventListener("DOMContentLoaded", function() {
    document.getElementById('classForm').addEventListener('submit', function(e) {
        e.preventDefault();

        let className = document.getElementById('className').value;
        let numPeople = document.getElementById('numPeople').value;
        let description = document.getElementById('description').value;

        let table = document.getElementById('classTable').getElementsByTagName('tbody')[0];
        let newRow = table.insertRow();
        newRow.innerHTML = `
            <td>${className}</td>
            <td>${numPeople}</td>
            <td>${description}</td>
        `;
        document.getElementById('classForm').reset();
    });

    // Input Focus Event
    document.querySelectorAll('input, textarea').forEach(input => {
        input.addEventListener('focus', function() {
            this.style.border = '2px solid blue';
        });
        input.addEventListener('blur', function() {
            this.style.border = '';
        });
    });

    // Double Click Event
    document.getElementById('classTable').addEventListener('dblclick', function(e) {
        if (e.target.tagName === 'TD') {
            e.target.parentNode.remove();
        }
    });

    
});
