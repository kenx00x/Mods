function add_perk( perk )
    table.insert(perk_list, perk)
end

add_perk({
		id = "BLEED_SWAMP",
		ui_name = "Bleed swamp",
		ui_description = "You bleed swamp, a disgusting liquid",
		ui_icon = "data/ui_gfx/perk_icons/swamp_blood.png",
		perk_icon = "data/items_gfx/perks/swamp_blood.png",
		usable_by_enemies = true,
		func = function( entity_perk_item, entity_who_picked, item_name )
		
			local damagemodels = EntityGetComponent( entity_who_picked, "DamageModelComponent" )
			if( damagemodels ~= nil ) then
				for i,damagemodel in ipairs(damagemodels) do
					ComponentSetValue( damagemodel, "blood_material", "swamp" )
					ComponentSetValue( damagemodel, "blood_spray_material", "swamp" )
					ComponentSetValue( damagemodel, "blood_multiplier", "3.0" )
					ComponentSetValue( damagemodel, "blood_sprite_directional", "data/particles/bloodsplatters/bloodsplatter_directional_swamp_$[1-3].xml" )
					ComponentSetValue( damagemodel, "blood_sprite_large", "data/particles/bloodsplatters/bloodsplatter_swamp_$[1-3].xml" )
				end
			end
			
		end,
})