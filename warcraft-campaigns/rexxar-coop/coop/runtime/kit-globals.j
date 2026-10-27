    integer array RC_oldSkill
    integer array RC_hpBit
    integer array RC_armorId
    integer RC_scanOwner = 0
    real RC_enemyLife = 4.5
    real RC_enemyDamage = 1.5
    boolean RC_damageBusy = false
    trigger RC_damageTrigger = null
    group RC_damageUnits = null
    group RC_balanceGroup = null
    timer RC_balanceTimer = null
    timer RC_skillTimer = null
    group RC_skillGroup = null
    real RC_skillTime = 0.0
    unit RC_huntTarget = null
    real RC_huntUntil = 0.0
    integer array RK_kind
    integer array RK_rank
    unit array RK_caster
    unit array RK_target
    unit array RK_marker
    effect array RK_visual
    group array RK_hits
    real array RK_x
    real array RK_y
    real array RK_dx
    real array RK_dy
    real array RK_age
    real array RK_limit
    real array RK_value
    integer array RK_phase
    integer array RC_talents
    integer array RC_talentLevel
    integer array RC_talentAnnounced
    string array RC_talentName
    string array RC_talentText
    string array RC_skillName
    dialog array RC_progressPanel
    button array RC_progressButton
    integer array RC_progressMode
    integer array RC_progressTier
