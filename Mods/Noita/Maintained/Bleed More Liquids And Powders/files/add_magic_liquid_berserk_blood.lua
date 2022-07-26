function add_perk( perk )
    table.insert(perk_list, perk)
end

add_perk({
		id = "BLEED_MAGIC_LIQUID_BERSERK",
		ui_name = "Bleed berserkium ",
		ui_description = "You bleed something that makes you so mad!",
		ui_icon = "data/ui_gfx/perk_icons/magic_liquid_berserk_blood.png",
		perk_icon = "data/items_gfx/perks/magic_liquid_berserk_blood.png",
		usable_by_enemies = true,
		func = function( entity_perk_item, entity_who_picked, item_name )
		
			local damagemodels = EntityGetComponent( entity_who_picked, "DamageModelComponent" )
			if( damagemodels ~= nil ) then
				for i,damagemodel in ipairs(damagemodels) do
					ComponentSetValue( damagemodel, "blood_material", "magic_liquid_berserk" )
					ComponentSetValue( damagemodel, "blood_spray_material", "magic_liquid_berserk" )
					ComponentSetValue( damagemodel, "blood_multiplier", "3.0" )
					ComponentSetValue( damagemodel, "blood_sprite_directional", "data/particles/bloodsplatters/bloodsplatter_directional_magic_liquid_berserk_$[1-3].xml" )
					ComponentSetValue( damagemodel, "blood_sprite_large", "data/particles/bloodsplatters/bloodsplatter_magic_liquid_berserk_$[1-3].xml" )
				end
			end
			
		end,
})