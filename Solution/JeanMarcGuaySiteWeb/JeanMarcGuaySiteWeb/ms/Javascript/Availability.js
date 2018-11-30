
    $(document).ready(function () {
        $('#scrollDefaultExample').timepicker({
            'disableTimeRanges': [
            ]
        });
    $('#scrollDefaultExample2').timepicker({
        'disableTimeRanges': [
    ]
      });

      $('#scrollDefaultExample').on('changeTime', function () {
        document.getElementById("ContentPlaceHolder1_time1l1").value = $(this).val();
    });

      $('#scrollDefaultExample2').on('changeTime', function () {
        document.getElementById("ContentPlaceHolder1_time2l1").value = $(this).val();
    });

});

  $( function() {
      var dialog, form,

    HeureDebut = $( "#hd" ),
    HeureFin = $( "#hf" ),
    allFields = $( [] ).add( HeureDebut ).add( HeureFin ),
    tips = $( ".validateTips" );

    function updateTips( t ) {
        tips
            .text(t)
            .addClass("ui-state-highlight");
    setTimeout(function() {
        tips.removeClass("ui-state-highlight", 1500);
    }, 500 );
  }


    function addTimeDay() {
      var valid = true;
      allFields.removeClass("ui-state-error");

      var button = document.getElementById("ContentPlaceHolder1_invisButton");
      button.click();
      //Check if time range is valid
         //Check if starting range lower than ending range
           //Check if range is already inside another range
      if ( valid ) {
        dialog.dialog("close");
    }
    return valid;
  }

    dialog = $( "#dialog-form" ).dialog({
        autoOpen: false,
    height: 400,
    width: 350,
    modal: true,
        buttons: {
        "Ajouter plage horraire": addTimeDay,
        Cancel: function() {
        dialog.dialog("close");
    }
  },
      close: function() {
        allFields.removeClass("ui-state-error");
    }
  });

    form = dialog.find( "form" ).on( "submit", function( event ) {
        event.preventDefault();
    addUser();
  });

      $(".create-date").button().on("click", function () {
        event.preventDefault();
    dialog.dialog( "open" );
  });
        });



        function storeDay(clicked_id) {
            document.getElementById("ContentPlaceHolder1_dayl1").value = clicked_id;
        }
