$( document ).ready(function() {
    $("a.no-link").click(function(e){
		e.preventDefault();
	});
	
	$("#proyectos-leyenda .leyenda-opcion").mouseenter(function() {
		$(this).addClass("rollover");
	}).mouseleave(function() {
		$(this).removeClass("rollover");
	});
	
	//para activar el grupo 1 por defecto
	$(".grupo_1").addClass("show");
	$(".imgGrupo_1").addClass("show");
	$("#pGrupo_1").addClass("active");
	
	$("#proyectos-leyenda .leyenda-opcion").click(function() {
		//$("#proyectos-leyenda .leyenda-opcion").removeClass("active");
		$(".sector").removeClass("show");
		$(".imgGrupo").removeClass("show");
		//id = $(this).attr("id").split("_")[1];
		limpiaSector();
		$(this).toggleClass("active");
		$("#proyectos-leyenda .leyenda-opcion").each(function(i,itm) {
			if($(itm).hasClass("active")){
				id = $(itm).attr("id").split("_")[1];
				$(".grupo_"+id).addClass("show");
				$(".imgGrupo_"+id).addClass("show");
			}
		});
		/*
		$(".grupo_"+id).toggleClass("show");
		$(".imgGrupo_"+id).toggleClass("show");
		*/
	});

	$(".proyectos .sector").click(function() {
		id=$(this).attr("id").split("_")[1];
		limpiaSector();
		$("#geoloc_"+id).addClass("show");
		$("#lineaA_"+id).addClass("show");
		$("#lineaB_"+id).addClass("show");
		$("#esfera_"+id).addClass("show");
		$("#popup_"+id).addClass("show");
	});
	$(".proyectos .sector").mouseenter(function() {
		id=$(this).attr("id").split("_")[1];
		if(!$("#geoloc_"+id).hasClass("show")){
			$("#geoloc_"+id).addClass("animate");
		}
	}).mouseleave(function() {
		id=$(this).attr("id").split("_")[1];
		$("#geoloc_"+id).removeClass("animate");
	});

	function limpiaSector(){
		$(".geoloc").removeClass("show animate");
		$(".lineaA").removeClass("show");
		$(".lineaB").removeClass("show");
		$(".esfera").removeClass("show");
		$(".p-popup").removeClass("show");
	}
});