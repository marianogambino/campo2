Event.observe(window, 'load', loadAccordions, false);

function loadAccordions() {
    var menu = new accordion('accordion',{
         defaultSize : {
            width : 200
         }
    });
    menu.activate($$('#accordion .accordion_toggle')[0]);
}