function add_perk( perk )
    table.insert(perk_list, perk)
end

add_perk({
		id = "BLEED_BLOOD_FUNGI",
		ui_name = "Bleed fungus blood",
		ui_description = "You bleed fungus blood, are you sure you're not a fungus?",
		ui_icon = "data/ui_gfx/perk_icons/blood_fungi_blood.png",
		perk_icon = "data/items_gfx/perks/blood_fungi_blood.png",
		usable_by_enemies = true,
		func = function( entity_perk_item, entity_who_picked, item_name )
		
			local damagemodels = EntityGetComponent( entity_who_picked, "DamageModelComponent" )
			if( damagemodels ~= nil ) then
				for i,damagemodel in ipairs(damagemodels) do
					ComponentSetValue( damagemodel, "blood_material", "blood_fungi" )
					ComponentSetValue( damagemodel, "blood_spray_material", "blood_fungi" )
					ComponentSetValue( damagemodel, "blood_multiplier", "3.0" )
					ComponentSetValue( damagemodel, "blood_sprite_directional", "data/particles/bloodsplatters/bloodsplatter_directional_blood_fungi_$[1-3].xml" )
					ComponentSetValue( damagemodel, "blood_sprite_large", "data/particles/bloodsplatters/bloodsplatter_blood_fungi_$[1-3].xml" )
				end
			end
			
		end,
})