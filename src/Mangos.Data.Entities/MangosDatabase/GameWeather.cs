using System.ComponentModel.DataAnnotations.Schema;

namespace Mangos.Data.Entities.MangosDatabase;

[Table("game_weather")]
public class GameWeather
{
    [Column("zone", TypeName="mediumint")]
    public virtual uint Zone { get; set; }

    [Column("spring_rain_chance", TypeName="tinyint")]
    public virtual byte SpringRainChance { get; set; }

    [Column("spring_snow_chance", TypeName="tinyint")]
    public virtual byte SpringSnowChance { get; set; }

    [Column("spring_storm_chance", TypeName="tinyint")]
    public virtual byte SpringStormChance { get; set; }

    [Column("summer_rain_chance", TypeName="tinyint")]
    public virtual byte SummerRainChance { get; set; }

    [Column("summer_snow_chance", TypeName="tinyint")]
    public virtual byte SummerSnowChance { get; set; }

    [Column("summer_storm_chance", TypeName="tinyint")]
    public virtual byte SummerStormChance { get; set; }

    [Column("fall_rain_chance", TypeName="tinyint")]
    public virtual byte FallRainChance { get; set; }

    [Column("fall_snow_chance", TypeName="tinyint")]
    public virtual byte FallSnowChance { get; set; }

    [Column("fall_storm_chance", TypeName="tinyint")]
    public virtual byte FallStormChance { get; set; }

    [Column("winter_rain_chance", TypeName="tinyint")]
    public virtual byte WinterRainChance { get; set; }

    [Column("winter_snow_chance", TypeName="tinyint")]
    public virtual byte WinterSnowChance { get; set; }

    [Column("winter_storm_chance", TypeName="tinyint")]
    public virtual byte WinterStormChance { get; set; }

}