document.getElementById("clientForm").addEventListener("submit", function (event) {
    event.preventDefault();

    let clientId = document.getElementById("clientId").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let email = document.getElementById("email").value;

    // Use AJAX or fetch to send data to the server and update the database
    // Update the client list after successful submission
    updateClientList();
});

function resetForm() {
    document.getElementById("clientId").value = "0";
    document.getElementById("firstName").value = "";
    document.getElementById("lastName").value = "";
    document.getElementById("email").value = "";
}

function updateClientList() {
    // Use AJAX or fetch to retrieve client data from the server and update the list
    // Populate the clientList UL with the retrieved client data
}