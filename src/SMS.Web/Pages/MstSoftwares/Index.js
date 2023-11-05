$(function () {
    let l = abp.localization.getResource('SMS');
    let createModal = new abp.ModalManager(abp.appPath + 'MstSoftwares/CreateModal');
    let editModal = new abp.ModalManager(abp.appPath + 'MstSoftwares/EditModal');


    let dataTable = $('#MstSoftwaresTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(sMS.mstSoftwares.mstSoftware.getList),
            columnDefs: [
                {
                    title: l('SoftwareCode'),
                    data: "softwareCode"
                },
                {
                    title: l('SoftwareName'),
                    data: "softwareName",
                    
                },
                {
                    title: l('SoftwareDescription'),
                    data: "softwareDescription",
                    
                },
                {
                    title: l('SoftwareStatus'),
                    data: "softwareStatus",
                    render: function (data) {
                        return l('Enum:SoftwareStatus.' + data);
                    }
                },

                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                }
                            ]
                    }
                },
                
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMstSoftwareButton').click(function (e) {
        e.preventDefault();
        createModal.open();

        console.log("???");
    });

});
