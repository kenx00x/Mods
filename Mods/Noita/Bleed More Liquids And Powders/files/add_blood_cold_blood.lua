function add_perk( perk )
    table.insert(perk_list, perk)
end

add_perk({
		id = "BLEED_BLOOD_COLD",
		ui_name = "Bleed freezing liquid",
		ui_description = "You bleed a very cold liquid that almost instantly vaporises",
		ui_icon = "data/ui_gfx/perk_icons/blood_cold_blood.png",
		perk_icon = "data/items_gfx/perks/blood_cold_blood.png",
		usable_by_enemies = true,
		func = function( entity_perk_item, entity_who_picked, item_name )
		
			local damagemodels = EntityGetComponent( entity_who_picked, "DamageModelComponent" )
			if( damagemodels ~= nil ) then
				for i,damagemodel in ipairs(damagemodels) do
					ComponentSetValue( damagemodel, "blood_material", "blood_cold" )
					ComponentSetValue( damagemodel, "blood_spray_material", "blood_cold" )
					ComponentSetValue( damagemodel, "blood_multiplier", "3.0" )
					ComponentSetValue( damagemodel, "blood_sprite_directional", "data/particles/bloodsplatters/bloodsplatter_directional_blood_cold_$[1-3].xml" )
					ComponentSetValue( damagemodel, "blood_sprite_large", "data/particles/bloodsplatters/bloodsplatter_blood_cold_$[1-3].xml" )
				end
			end
			
		end,
})