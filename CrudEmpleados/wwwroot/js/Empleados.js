var DTEmpleado = null;
const confDTEmpleado = {
    "language": { "sUrl": "./assets/js/dataTables_Espanol.json" },
    "pageLength": 10,
    "paging": true,
    "lengthChange": false,
    "pageResize": true,
    "pagingType": "simple_numbers",
    "info": false,
    "ordering": false,
    "searching": false,
    "autoWidth": false,
    "responsive": true,
    "serverSide": false,
    "select": true,
    dom: 'l<"cls-btn-export"B>frtip',
    buttons: [
        {
            text: '.',
            extend: 'excel'
            , className: 'export-excel'
            , title: "check_oper_oxxo" + (new Date().toISOString().slice(0, 10)) + "_" + (new Date().getTime()),
            extension: '.xls'
        }
    ]
    , "columnDefs": [
        { "name": "sNombre", "data": "sNombre", "className": "text-center", "targets": 0 }
        , { "name": "sCorreo", "data": "sCorreo", "className": "text-center", "targets": 1 }
        , { "name": "dtFechaIngreso", "data": "dtFechaIngreso", "className": "text-center", "targets": 2 }
        , {
            "name": "acciones", "data": "acciones", "className": "text-center", "targets": 3, render: function (data, type, row, meta) {
                // return data;
                return type === 'display' ?
                    `<button data-id="${row.id}" id="updaterow" onclick='updateEmpleado(${JSON.stringify(row)})' type="button" class="btn update btn-primary btn-sm" ><i class="fa fa-pencil" ></i></button>
                 <button data-id="${row.id}" id="deleterow" onclick='deleteEmpleado(${JSON.stringify(row)},4)' class="btn delete btn-danger btn-sm" ><i class='fa fa-trash'></i></button>` : data;
            } }
    ]
};

$(document).ready(function () {
    fetch('/Home/ObtenerRegistros')
        .then(response => response.json())
        .then(data => {
            var divMain = document.getElementById("main-app")
            if (data.length > 0) {
                if (typeof (DTReversa) !== "undefined" && DTReversa !== null) {
                    DTReversa.clear();
                    DTReversa.destroy();
                }//fin:if ( typeof(DTBoletaje) !== "undefined" && DTBoletaje !== null )
                $('div#Empleado').remove();
                var sTemplate = fnCrearTabla();
                htmlObject = document.createElement('div');
                htmlObject.setAttribute("id", "Empleado");
                htmlObject.setAttribute("style", "width:100%; height:100%;");
                htmlObject.innerHTML = sTemplate;
                $('#main-app').append(htmlObject);

                DTEmpleado = $('table#tbl-Empleado').DataTable(confDTEmpleado);
                DTEmpleado.clear().draw();

                $("div#respuestaCheckOper").show();
                $("#errorCheckOper").hide();

                $.each(data, function (_index, _oData) {
                    DTEmpleado.row.add({
                        "sNombre": _oData.sNombre
                        , "sCorreo": "'" + _oData.sCorreo
                        , "dtFechaIngreso": _oData.dtFechaIngreso
                        , "acciones": ""
                    });
                });//fin:$.each()
                DTEmpleado.draw();
                DTEmpleado.columns.adjust().draw();
            } else {
                var sTemplate = `<div>
                    <img src="~/../images/nodata.png" style="width: 25%;margin-right: auto;margin-left: auto;display: block;">
                </div>`;
                divMain.appendChild;
                htmlObject = document.createElement('div');
                htmlObject.setAttribute("id", "Empleado");
                htmlObject.setAttribute("style", "width:100%; height:100%;");
                htmlObject.innerHTML = sTemplate;
                $('#main-app').append(htmlObject);
            }
        });
});

const fnCrearTabla = () => {
    sTemplate = `
        <h4 style="margin-bottom: 0px;">Empleados &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <a id="boton" onclick="fnDescargarCSV(this)" class="mb-2 text-center btn btn-primary">DESCARGAR CSV</a></h4>
        <div id="respuestaEmpleados" class="">
            <div data-topline="1">
                <table style="background: transparent;" width='100%' id='tbl-Empleado' class='table dt-responsive responsive hover nowrap'>
                    <thead>
                        <tr style="color:#fffff; background: transparent;" id="header_Empleados">
                            <th>Nombre</th>
                            <th>Correo</th>
                            <th>FechaIngreso</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody style="color:#fffff; background: transparent;" id="body_empleados"></tbody>
                </table>
            </div>
        </div>`;
    return sTemplate
}