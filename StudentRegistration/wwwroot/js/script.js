document.addEventListener('DOMContentLoaded', function() {
    // Handle profile picture upload
    const profileUpload = document.getElementById('profile-upload');
    const profilePic = document.getElementById('profile-pic');
    
    profileUpload.addEventListener('change', function(e) {
        if (e.target.files && e.target.files[0]) {
            const reader = new FileReader();
            
            reader.onload = function(event) {
                profilePic.src = event.target.result;
            }
            
            reader.readAsDataURL(e.target.files[0]);
        }
    });
    
    // Form submission
    const form = document.querySelector('#panel3 form');
    form.addEventListener('submit', function(e) {
        e.preventDefault();
        alert('Form submitted successfully!');
        // Here you would typically send the data to a server
    });
});

// Panel navigation functions
function nextPanel(currentPanel) {
    document.getElementById('panel' + currentPanel).classList.remove('active');
    document.getElementById('panel' + (currentPanel + 1)).classList.add('active');
    
    // Update progress bar
    const progress = (currentPanel / 3) * 100;
    document.querySelector('.progress-bar').style.width = progress + '%';
}

function prevPanel(currentPanel) {
    document.getElementById('panel' + currentPanel).classList.remove('active');
    document.getElementById('panel' + (currentPanel - 1)).classList.add('active');
    
    // Update progress bar
    const progress = ((currentPanel - 2) / 3) * 100;
    document.querySelector('.progress-bar').style.width = progress + '%';
}

document.getElementById('profile-upload').addEventListener('change', function (e) {
    const file = e.target.files[0];
    const profilePic = document.getElementById('profile-pic');

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            profilePic.src = e.target.result;
        }
        reader.readAsDataURL(file);
    } else {
        profilePic.src = '/images/student.PNG';
    }
});