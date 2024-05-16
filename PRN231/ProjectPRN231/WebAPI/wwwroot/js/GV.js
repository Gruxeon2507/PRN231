const viewDeadlineBtn = document.getElementById('viewDeadlineBtn');
const deadlineModal = document.getElementById('deadlineModal');
const closeModal = document.getElementsByClassName('close')[0];

viewDeadlineBtn.addEventListener('click', () => {
    deadlineModal.style.display = 'block';
});

closeModal.addEventListener('click', () => {
    deadlineModal.style.display = 'none';
});

window.addEventListener('click', (event) => {
    if (event.target === deadlineModal) {
        deadlineModal.style.display = 'none';
    }
});