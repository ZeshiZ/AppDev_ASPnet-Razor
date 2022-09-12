var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/product/Index"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "barcode", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div></div>`
                },
                "width": "15%"
            }
        ]
    });
}