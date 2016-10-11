$(function () {
    $(document).ready(function () {
        $('INPUT[type="text"]').focus(function () {
            $(this).addClass("focus");
        });

        $('INPUT[type="text"]').blur(function () {
            $(this).removeClass("focus");
        });
        $.ajax({
            type: "GET",
            url: "/Stock/gmid",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#txtRID1').val(data);
                $('#txtRID').val(data);
                $('#txtCNAME').focus();
            }
        });
    });

    $('#txtCNAME').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSSTA').val("NEW");
            $('#txtDPCODE').val("A1587");
            $('#txtLMODI').val(new Date($.now()));
            $('#txtAEDT').val("NEW");
            $('#txtRID1').val(new Date($.now()));
            $('#txtSNAME').focus();
            e.preventDefault();
        }
    });
    $('#txtRID1').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCNAME').focus();
            e.preventDefault();
        }
    });
    $('#txtSNAME').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSID').focus();
            e.preventDefault();
        }
    });

    $('#txtSID').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtADDR').focus();
            e.preventDefault();
        }
    });

    $('#txtADDR').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtDIST').focus();
            e.preventDefault();
        }
    });

    $('#txtDIST').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSTATE').focus();
            e.preventDefault();
        }
    });

    $('#txtSTATE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCPN').focus();
            e.preventDefault();
        }
    });

    $('#txtCPN').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtPHNO').focus();
            e.preventDefault();
        }
    });

    $('#txtPHNO').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtOEA').focus();
            e.preventDefault();
        }
    });

    $('#txtOEA').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtDOC').focus();
            e.preventDefault();
        }
    });

    $('#txtDOC').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtAMC').focus();
            e.preventDefault();
        }
    });

    $('#txtAMC').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtWARR').focus();
            e.preventDefault();
        }
    });

    $('#txtWARR').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtRATPH').focus();
            e.preventDefault();
        }
    });

    $('#txtRATPH').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtPHASE').focus();
            e.preventDefault();
        }
    });

    $('#txtPHASE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtMODEL').focus();
            e.preventDefault();
        }
    });

    $('#txtMODEL').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtENS').focus();
            e.preventDefault();
        }
    });

    $('#txtENS').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtDGNO').focus();
            e.preventDefault();
        }
    });

    $('#txtDGNO').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtAMAKE').focus();
            e.preventDefault();
        }
    });

    $('#txtAMAKE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtALSN').focus();
            e.preventDefault();
        }
    });

    $('#txtALSN').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtFRAME').focus();
            e.preventDefault();
        }
    });

    $('#txtFRAME').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtBSN').focus();
            e.preventDefault();
        }
    });

    $('#txtBSN').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtLLOP').focus();
            e.preventDefault();
        }
    });

    $('#txtLLOP').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSOLENOID').focus();
            e.preventDefault();
        }
    });

    $('#txtSOLENOID').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCHALT').focus();
            e.preventDefault();
        }
    });

    $('#txtCHALT').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSTARTER').focus();
            e.preventDefault();
        }
    });

    $('#txtSTARTER').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCNTYPE').focus();
            e.preventDefault();
        }
    });

    $('#txtCNTYPE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCNMAKE').focus();
            e.preventDefault();
        }
    });

    $('#txtCNMAKE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSAUTO').focus();
            e.preventDefault();
        }
    });

    $('#txtSAUTO').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCHMR').focus();
            e.preventDefault();
        }
    });
$('#txtCHMR').focus(function (e) {
	$('#txtCHMR').val("2");
	$('#txtCHMD').val($('#txtDOC').val());
});
    $('#txtCHMR').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtCHMD').focus();
            e.preventDefault();
        }
    });

    $('#txtCHMD').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtLHMR').focus();
            e.preventDefault();
        }
    });

    $('#txtLHMR').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtLSD').focus();
            e.preventDefault();
        }
    });

    $('#txtLSD').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtNSD').focus();
            e.preventDefault();
        }
    });

    $('#txtNSD').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtSPIN').focus();
            e.preventDefault();
        }
    });

    $('#txtSPIN').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtHMAGE').focus();
            e.preventDefault();
        }
    });

    $('#txtHMAGE').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtAHM').focus();
            e.preventDefault();
        }
    });

    $('#txtAHM').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtDSTA').focus();
            e.preventDefault();
        }
    });

    $('#txtDSTA').keypress(function (e) {
        if (e.keyCode == 13) {
            $('#txtACTION').focus();
            e.preventDefault();
        }
    });

    $("#txtCNAME").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/CUST',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtOEA").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/OEA',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtAMAKE").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/AMAKE',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtDIST").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/DIST',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtSTATE").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/STATE',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtLLOP").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/LLOP',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtSTARTER").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/STARTER',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtCHALT").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/CHALT',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtCNMAKE").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/CNMAKE',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtAMC").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/AMC',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtWARR").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/WARR',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtMODEL").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/MODEL',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtSPIN").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/SPIN',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtDSTA").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/DSTA',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $("#txtSOLENOID").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Pop/SOLENOID',
                type: "POST",
                dataType: "json",
                data: { term: request.term },
                success: function (data) {
                    response(data);
                }
            });
        }
    });
    $(function () {
        $.datetimepicker.setLocale('en');
        $('#txtDOC').datetimepicker({
            format: 'd-M-Y H:i',
            step: 1,
        });
        $('#txtCHMD').datetimepicker({
            format: 'd-M-Y H:i',
            step: 1,
        });
    });
});