document.getElementById("clientForm").addEventListener("submit", function (event) {
    event.preventDefault();

    let clientId = document.getElementById("clientId").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let email = document.getElementById("email").value;

    // Use a hidden input field to indicate the action (add or update)
    let action = clientId === "0" ? "add" : "update";

    // Set the action to be submitted
    document.getElementById("action").value = action;

    // Submit the form (will cause a page reload)
    document.getElementById("clientForm").submit();
});

function resetForm() {
    document.getElementById("clientId").value = "0";
    document.getElementById("firstName").value = "";
    document.getElementById("lastName").value = "";
    document.getElementById("email").value = "";
}

function deleteClient(clientId) {
    // Set the client ID to be deleted
    document.getElementById("clientId").value = clientId;

    // Set the action to be delete
    document.getElementById("action").value = "delete";

    // Submit the form (will cause a page reload)
    document.getElementById("clientForm").submit();
}