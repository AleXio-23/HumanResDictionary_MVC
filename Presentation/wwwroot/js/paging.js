
const RECORD_PER_PAGE = 5;
let currentPage = 1;

const createButton = (innerTextString) => {

    const pageNumberDiv = document.createElement('div');
    pageNumberDiv.onclick = () => onPagingInputClick(pageNumberDiv, innerTextString);
    pageNumberDiv.classList.add('paging-numbers');
    if (innerTextString === currentPage) {

        pageNumberDiv.classList.add('paging-number-active');
    }
    pageNumberDiv.innerText = innerTextString;
    return pageNumberDiv;
}

const initiatePageNumbers = () => {
    let totalPages = Math.ceil(RECORDS_COUNT / RECORD_PER_PAGE);
    const pagingArea = document.getElementById("paging-number-area");
    pagingArea.innerHTML = '';


    initialisePersonsList(1 + (RECORD_PER_PAGE * (currentPage - 1)), RECORD_PER_PAGE);

    if (totalPages < 8) {
        createFullPagingButtons(totalPages, pagingArea);
    } else {
        createGappedPaging(totalPages, pagingArea)
    }

}

const createFullPagingButtons = (totalPages, element) => {

    for (let i = 1; i <= totalPages; i++) {
        element.appendChild(createButton(i));
    }
}

const createGappedPaging = (totalPages, element) => {

    if (currentPage < 4) {
        for (let i = 1; i <= 5; i++) {
            element.appendChild(createButton(i));
        }
        appendWithAfterGap(element, totalPages);
        element.appendChild(createButton(totalPages));
    } else if (currentPage === 4) {
        for (let i = 1; i <= 6; i++) {
            element.appendChild(createButton(i));
        }
        appendWithAfterGap(element, totalPages);
        element.appendChild(createButton(totalPages));
    } else if (totalPages - currentPage < 3) {
        element.appendChild(createButton(1));
        appendWithBeforeGap(element);
        for (let i = totalPages - 4; i <= totalPages; i++) {
            element.appendChild(createButton(i));
        }
    }
    else if (totalPages - currentPage === 3) {
        element.appendChild(createButton(1));
        appendWithBeforeGap(element);
        for (let i = totalPages - 5; i <= totalPages; i++) {
            element.appendChild(createButton(i));
        }
    } else {
        element.appendChild(createButton(1));
        appendWithBeforeGap(element);
        for (let i = currentPage - 2; i <= currentPage + 2; i++) {
            element.appendChild(createButton(i));
        }
        appendWithAfterGap(element, totalPages);
        element.appendChild(createButton(totalPages));
    }

}


const appendWithAfterGap = (element, totalPages) => {

    const afterGapBtn = document.createElement('div');
    afterGapBtn.onclick = () => {
        if (totalPages - currentPage < 5) {
            currentPage = totalPages;
        } else {
            currentPage += 5;
        }

        initiatePageNumbers();
    };
    afterGapBtn.classList.add('paging-numbers');
    afterGapBtn.classList.add('afterGapBtn');


    const defaultText = document.createElement('span');
    defaultText.className = 'text default';
    defaultText.innerText = '...';

    const hoverText = document.createElement('span');
    hoverText.className = 'text hover';
    hoverText.innerText = '>>';
    hoverText.style.opacity = '0';
    hoverText.style.display = 'none';


    afterGapBtn.appendChild(defaultText);
    afterGapBtn.appendChild(hoverText);

    afterGapBtn.addEventListener('mouseover', () => {
        defaultText.style.opacity = '0';
        defaultText.style.display = 'none';
        hoverText.style.display = 'block';
        hoverText.style.opacity = '1';
    });

    afterGapBtn.addEventListener('mouseout', () => {
        hoverText.style.opacity = '0';
        hoverText.style.display = 'none';
        defaultText.style.display = 'block';
        defaultText.style.opacity = '1';
    });

    element.appendChild(afterGapBtn);
}


const appendWithBeforeGap = (element) => {
    const beforeGapBtn = document.createElement('div');
    beforeGapBtn.onclick = () => {
        if (currentPage - 1 < 5) {
            currentPage = 1;
        } else {
            currentPage -= 5;
        }

        initiatePageNumbers();
    };
    beforeGapBtn.classList.add('paging-numbers');
    beforeGapBtn.classList.add('afterGapBtn');


    const defaultText = document.createElement('span');
    defaultText.className = 'text default';
    defaultText.innerText = '...';

    const hoverText = document.createElement('span');
    hoverText.className = 'text hover';
    hoverText.innerText = '<<';
    hoverText.style.opacity = '0';
    hoverText.style.display = 'none';


    beforeGapBtn.appendChild(defaultText);
    beforeGapBtn.appendChild(hoverText);

    beforeGapBtn.addEventListener('mouseover', () => {
        defaultText.style.opacity = '0';
        defaultText.style.display = 'none';
        hoverText.style.display = 'block';
        hoverText.style.opacity = '1';
    });

    beforeGapBtn.addEventListener('mouseout', () => {
        hoverText.style.opacity = '0';
        hoverText.style.display = 'none';
        defaultText.style.display = 'block';
        defaultText.style.opacity = '1';
    });


    element.appendChild(beforeGapBtn);
}


const onPagingInputClick = (element, page) => {
    currentPage = page
    initiatePageNumbers();
}

initiatePageNumbers();

 