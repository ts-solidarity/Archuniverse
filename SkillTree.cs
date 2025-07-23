using Archuniverse;
using Archuniverse.Characters;
using System.Net.Http.Headers;

public class SkillTree : Base
{
    public LivingEntity Owner { get; }
    public List<Skill> AllSkills { get; } = [];
    public int UnusedSkillPoints { get; private set; } = 0;

    public SkillTree(LivingEntity owner)
    {
        Owner = owner;
        var strongBody = new Skill("Strong Body", "Increases Max Health by 50", 2,
            entity => entity.MaxHealth += 50);

        var trainedMind = new Skill("Trained Mind", "Increases Max Mana by 40", 2,
            entity => entity.MaxMana += 40);

        var fasterRegen = new Skill("Faster Regen", "Regenerate +2 HP/turn", 3,
            entity => entity.HealthRegeneration += 2);
        var carrier = new Skill("Carrier", "Doubling the max inventory", 5, 
            entity =>
            {
                if (entity is Character character)
                {
                    character.InventoryCapacity *= 2;
                }
            });
        var ironBody = new Skill("Iron Body", "Increases base defence by 30", 2,
    entity => entity.BaseDefence += 30);

        AddSkill(strongBody);
        AddSkill(trainedMind);
        AddSkill(fasterRegen);
        AddSkill(carrier);
        AddSkill(ironBody);
    }

    public void AddSkill(Skill skill)
    {
        if (!AllSkills.Contains(skill))
            AllSkills.Add(skill);
    }

    public void GainSkillPoint()
    {
        UnusedSkillPoints++;
    }

    public bool UnlockSkill(string skillName)
    {
        var skill = AllSkills.FirstOrDefault(s => s.Name == skillName);
        if (skill == null || UnusedSkillPoints <= 0 || !skill.CanUnlock(Owner))
            return false;

        if (skill.Unlock(Owner))
        {
            UnusedSkillPoints--;
            return true;
        }

        return false;
    }
}
