// Function to display toast notifications
function showToast(message, type = 'success') {
    const toast = document.createElement('div');
    toast.className = `toast show align-items-center text-white bg-${type} border-0`;
    toast.setAttribute('role', 'alert');
    toast.setAttribute('aria-live', 'assertive');
    toast.setAttribute('aria-atomic', 'true');

    toast.innerHTML = `
        <div class="d-flex">
            <div class="toast-body">
                ${message}
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
    `;

    const toastContainer = document.getElementById('toastContainer') || createToastContainer();
    toastContainer.appendChild(toast);

    setTimeout(() => {
        toast.remove();
    }, 5000);
}

function createToastContainer() {
    const container = document.createElement('div');
    container.id = 'toastContainer';
    container.style.position = 'fixed';
    container.style.top = '20px';
    container.style.right = '20px';
    container.style.zIndex = '9999';
    document.body.appendChild(container);
    return container;
}

// Initialize tooltips
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

// Datepicker initialization for booking dates
$(document).ready(function () {
    $('.datepicker').datepicker({
        format: 'yyyy-mm-dd',
        autoclose: true,
        todayHighlight: true,
        startDate: new Date()
    });
});
document.getElementById('goBack').addEventListener('click', function () {
    window.history.back();
});
// Calculate total amount when dates change
$('#CheckInDate, #CheckOutDate').change(function () {
    const checkIn = new Date($('#CheckInDate').val());
    const checkOut = new Date($('#CheckOutDate').val());

    if (checkIn && checkOut && checkOut > checkIn) {
        const days = Math.round((checkOut - checkIn) / (1000 * 60 * 60 * 24));
        const pricePerNight = parseFloat($('#PricePerNight').val()) || 0;
        $('#TotalAmount').val((days * pricePerNight).toFixed(2));
    }
});
