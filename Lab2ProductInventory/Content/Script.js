'use strict';
window.addEventListener("load", function () {
    adjustTablePadding();
});

window.addEventListener("resize", function () {
    adjustTablePadding();
});

function adjustTablePadding() {
    var tblContent = document.querySelector('.tbl-content');
    var tblTable = tblContent.querySelector('table');
    var scrollWidth = tblContent.offsetWidth - tblTable.offsetWidth;
    var tblHeader = document.querySelector('.tbl-header');
    tblHeader.style.paddingRight = scrollWidth + 'px';
}

// Call the function initially
adjustTablePadding();
