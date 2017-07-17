
$("#navbar")
    .scroll()(function() {
        if ($(this).affix < 10) {
            $(this).attr('id', 'affix');
        }
    });

