function add_perk( perk )
    table.insert(perk_list, perk)
end

add_perk({
		id = "BLEED_SAND",
		ui_name = "Bleed sand",
		ui_description = "You bleed... sand... that's not even a liquid...",
		ui_icon = "data/ui_gfx/perk_icons/sand_blood.png",
		perk_icon = "data/items_gfx/perks/sand_blood.png",
		usable_by_enemies = true,
		func = function( entity_perk_item, entity_who_picked, item_name )
		
			local damagemodels = EntityGetComponent( entity_who_picked, "DamageModelComponent" )
			if( damagemodels ~= nil ) then
				for i,damagemodel in ipairs(damagemodels) do
					ComponentSetValue( damagemodel, "blood_material", "sand" )
					ComponentSetValue( damagemodel, "blood_spray_material", "sand" )
					ComponentSetValue( damagemodel, "blood_multiplier", "3.0" )
					ComponentSetValue( damagemodel, "blood_sprite_directional", "data/particles/bloodsplatters/bloodsplatter_directional_sand_$[1-3].xml" )
					ComponentSetValue( damagemodel, "blood_sprite_large", "data/particles/bloodsplatters/bloodsplatter_sand_$[1-3].xml" )
				end
			end
			
		end,
})