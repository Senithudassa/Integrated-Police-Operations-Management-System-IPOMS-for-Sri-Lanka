const apiBaseUrl = "https://localhost:5001/api/Admin";

// Load Admins on Page Load
document.addEventListener("DOMContentLoaded", loadAdmins);

function loadAdmins() {
    fetch(apiBaseUrl)
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("adminTableBody");
            tableBody.innerHTML = ""; // Clear existing rows

            data.forEach(admin => {
                const row = `
                    <tr>
                        <td>${admin.adminId}</td>
                        <td>${admin.firstName}</td>
                        <td>${admin.lastName}</td>
                        <td>${admin.email}</td>
                        <td>${admin.phoneNumber || "N/A"}</td>
                        <td>
                            <button onclick="editAdmin(${admin.adminId})">Edit</button>
                            <button onclick="deleteAdmin(${admin.adminId})">Delete</button>
                        </td>
                    </tr>
                `;
                tableBody.innerHTML += row;
            });
        })
        .catch(error => console.error("Error loading admins:", error));
}

// Handle Form Submission for Add/Update
document.getElementById("adminForm").addEventListener("submit", function (event) {
    event.preventDefault();

    const adminId = document.getElementById("adminId").value;
    const adminData = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("email").value,
        phoneNumber: document.getElementById("phoneNumber").value,
        password: document.getElementById("password").value // Include password
    };

    if (adminId) {
        // Update Admin
        fetch(${ apiBaseUrl } / ${ adminId }, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(adminData)
        })
            .then(response => {
                if (response.ok) {
                    alert("Admin updated successfully");
                    loadAdmins();
                    document.getElementById("adminForm").reset();
                }
            })
            .catch(error => console.error("Error updating admin:", error));
    } else {
        // Add New Admin
        fetch(apiBaseUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(adminData)
        })
            .then(response => {
                if (response.ok) {
                    alert("Admin added successfully");
                    loadAdmins();
                    document.getElementById("adminForm").reset();
                }
            })
            .catch(error => console.error("Error adding admin:", error));
    }
});

// Edit Admin
function editAdmin(adminId) {
    fetch(${ apiBaseUrl } / ${ adminId })
        .then(response => response.json())
        .then(admin => {
            document.getElementById("adminId").value = admin.adminId;
            document.getElementById("firstName").value = admin.firstName;
            document.getElementById("lastName").value = admin.lastName;
            document.getElementById("email").value = admin.email;
            document.getElementById("phoneNumber").value = admin.phoneNumber || "";
            document.getElementById("password").value = ""; // Clear password for security
        })
        .catch(error => console.error("Error fetching admin:", error));
}

// Delete Admin
function deleteAdmin(adminId) {
    if (confirm("Are you sure you want to delete this admin?")) {
        fetch(${ apiBaseUrl } / ${ adminId }, { method: "DELETE" })
            .then(response => {
                if (response.ok) {
                    alert("Admin deleted successfully");
                    loadAdmins();
                }
            })
            .catch(error => console.error("Error deleting admin:", error));
    }
}