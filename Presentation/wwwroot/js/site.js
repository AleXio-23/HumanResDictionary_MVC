

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
                    <td>${person.birthDate}</td>
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

function displayAvatarOrPlaceholder(avatarUrl, firstname, lastname) {
    console.log(avatarUrl)
    if (avatarUrl === null || avatarUrl === '' || avatarUrl === undefined) {
        return `<span>${firstname.charAt(0)}${lastname.charAt(0)}</span>`;
    } else {
        return `<img src="${avatarUrl}" alt="Avatar">`;
    }
}