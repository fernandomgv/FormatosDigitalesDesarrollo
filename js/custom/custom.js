jQuery.noConflict()(function($){
	$(document).ready(function(){
	$("#carrusel").jFlow({
		controller: ".jFlowControl", // must be class, use . sign
		slideWrapper : "#jFlowSlider", // must be id, use # sign
		slides: "#mySlides",  // the div where all your sliding divs are nested in
		selectedWrapper: "jFlowSelected",  // just pure text, no sign		
		effect: "rewind", //this is the slide effect (rewind or flow)
		width: "1000px",  // this is the width for the content-slider
		height: "360px",  // this is the height for the content-slider
		duration: 500,  // time in milliseconds to transition one slide		
		pause: 3000, //time between transitions
		//prev: ".jFlowPrev", // must be class, use . sign
		//next: ".jFlowNext", // must be class, use . sign
		auto: true	
    });	
	$("#pagnoticia").jFlow({
			controller: ".jFlowControlnoti",
			slideWrapper : "#noticias",
			slides: "#noticia",
			selectedWrapper: "jFlowSelectednoti",
			width: "450px",
			height: "197px",
			duration: 500,
			auto: true
		});
	$("#nivoslider-15").nivoSlider({
        effect:"sliceUpDownLeft",
        slices:15,
        boxCols:8,
        boxRows:4,
        animSpeed:5000,
        pauseTime:10000,
        startSlide:0,
        directionNav:false,
        controlNav:true,
        controlNavThumbs:false,
        pauseOnHover:false,
        manualAdvance:false
    });	

});

});



