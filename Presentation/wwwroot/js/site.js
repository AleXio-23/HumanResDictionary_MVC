function populateTable(persons) {
    const tableContentArea = document.getElementById('usersTable');
    persons.forEach(person => {
        const row = document.createElement('tr');

        row.innerHTML = `
                    <td  >
                        <span class="td-center">
                             ${person.id}
                        </span>
                    </td>
                    <td class="tb-column">
                        <div class="person-area">
                            <div class="avatar">
                                ${displayAvatarOrPlaceholder(person.avatar, person.firstname, person.lastname)}
                            </div>
                            <div class="fullname">
                                <span>${person.firstname} ${person.lastname}</span>
                            </div>
                        </div>
                    </td>
                   
                    <td>${person?.gender?.localizedGenderNames[0]?.name ?? "----"}</td>
                    <td>${person.personalNumber}</td>
                    <td>${formatDateToDDMMYYYY(person.birthDate)} </td>
                    <td>${person.city.localizedNames[0].name}</td>
                    <td>${person.phoneNumber}</td>
                    <td>${person.relatedPersonsCount}</td> 
                    <td> 
                        <span><i class="bi bi-info-circle"></i></span>
                        <span><i class="bi bi-pencil-square"></i></span>
                        <span><i class="bi bi-trash3"></i></span>
                    </td>
                `;

        tableContentArea.appendChild(row);
    });
}

function formatDateToDDMMYYYY(dateString) {
    // Convert the dateString to a Date object
    const date = new Date(dateString);

    // Check if the conversion was successful
    if (isNaN(date.getTime())) {
        // Handle invalid date
        console.error('Invalid date:', dateString);
        return '';
    }

    // Extract day, month, and year
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
    const year = date.getFullYear();

    // Return formatted date string
    return `${day}/${month}/${year}`;
}

function displayAvatarOrPlaceholder(avatarUrl, firstname, lastname) {
    console.log(avatarUrl)
    if (avatarUrl === null || avatarUrl === '' || avatarUrl === undefined) {
        return `<span>${firstname.charAt(0)}${lastname.charAt(0)}</span>`;
    } else {
        return `<img src="${avatarUrl}" alt="Avatar">`;
    }
}